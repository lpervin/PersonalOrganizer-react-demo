import React, { useEffect, useState }  from 'react';
import { Badge, Nav, Navbar } from 'react-bootstrap';
import { useAuth0 } from "@auth0/auth0-react";
import { observer } from "mobx-react-lite";
import LoginButton from '../login-button';
import LogoutButton from '../logout-button';
import { Link } from 'react-router-dom';
import { RootStoreContext } from '../../../stores/RootStore';
import { UserStoreContext } from '../../../stores/UserStore';
import  Loading  from '../Loading'
import UserProfile from '../../../models/UserProfile';




const AuthNav = observer( () => {
 
        const { isAuthenticated,isLoading, user, getAccessTokenSilently } = useAuth0();
        const userContext = React.useContext(UserStoreContext);

        useEffect( () => {
                const getAccessToken = async () => {
                         try {
                              const token = await getAccessTokenSilently({
                                        audience: process.env.REACT_APP_AUTH0_AUDIENCE
                                });  
                       
                               // console.log('got Silently: ', token)   
                                return token;   
                         } 
                         catch(e){
                                console.log(e.message);      
                         }      
                };
                if (isAuthenticated)
                {
                             getAccessToken().then((token) => {
                                       // console.log('I got it: ', token);                                     
                                        userContext.userProfile = {  accessToken: token, ...user};                                                
                            });
                            
                }
                else{
                        userContext.userProfile = null;
                        
                }
            

            }, [isAuthenticated]);
   
    const store = React.useContext(RootStoreContext);  
    const noteStore = store.notesStore;
    const todoStore = store.todosStore;

    console.log(isLoading);
    if (isLoading) {
            return <Loading className='text-danger'></Loading>;
    }

        
            //        userContext.userProfile = user;
            
                
    return (    
              <Nav className="mr-md-0">                
                  {isAuthenticated ?   <Navbar.Collapse className="justify-content-end">
                                              <Navbar.Text> Tasks: <Link to='/notes'><Badge variant="danger">{todoStore.totalTodosCount()}</Badge> </Link></Navbar.Text>
                                              <Navbar.Text> &nbsp;Complted Tasks: <Link to='/notes'><Badge variant="success">{todoStore.completedTodosCount()}</Badge> </Link></Navbar.Text>
                                              <Navbar.Text> &nbsp;Notes: <Link to='/notes'><Badge variant="light">{noteStore.notesCount()}</Badge></Link></Navbar.Text>                
                                              <div>&nbsp;&nbsp;&nbsp;</div>
                                              <div>{user.name}</div>
                                              <LogoutButton />
      </Navbar.Collapse> : <LoginButton />}
              </Nav>
    
  );
});

export default AuthNav;