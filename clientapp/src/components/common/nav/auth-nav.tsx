import React, { useEffect, useState }  from 'react';
import { Badge, Dropdown, DropdownButton, Nav, Navbar } from 'react-bootstrap';
import { useAuth0 } from "@auth0/auth0-react";
import { observer } from "mobx-react-lite";
import LoginButton from '../login-button';
import LogoutButton from '../logout-button';
import { Link } from 'react-router-dom';
import { RootStoreContext } from '../../../stores/RootStore';
import { AuthenticationContext } from '../../../stores/UserAuthStore';
import  Loading  from '../Loading'
import {FaUserCircle, FaCog,FaCloud} from 'react-icons/fa';
import ToDosApi from '../../../api/ToDoApi';



const AuthNav = observer( () => {
 
        const { isAuthenticated, isLoading, user, getAccessTokenSilently } = useAuth0();
        const authContext = React.useContext(AuthenticationContext);
        const rootStore = React.useContext(RootStoreContext);  

        useEffect( () => {
                const getAccessToken = async () => {
                         try {
                              const token = await getAccessTokenSilently({
                                        audience: process.env.REACT_APP_AUTH0_AUDIENCE,
                                        scope: 'email profile'
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
                             getAccessToken().then(async (token) => {
                                       // console.log('I got it: ', token);                                     
                                       authContext.userProfile = {  accessToken: token, ...user};  
                                       //Not that token is fetched, init all stores (load with data)
                                       await rootStore.Init();                                              
                            });
                            
                            
                }
                else{
                        authContext.userProfile = null;
                        
                }
            

            }, [isAuthenticated]);
   
   
    const noteStore = rootStore.notesStore;
    const todoStore = rootStore.todosStore;

  //  console.log(isLoading);
    if (isLoading) {
            return <Loading className='text-danger'></Loading>;
    }

        
            //        userContext.userProfile = user;
        const testApi = async () => {
                try {
                                const response = await ToDosApi.test();
                                console.log(response);
                                alert('Ok');
                         }
                         catch(e){
                                 alert('Nope');
                                 console.log(e);
                         }
                
        };
                
    return (    
              <Nav className="mr-md-0">                
                  {isAuthenticated ?   <Navbar.Collapse className="justify-content-end">
                                              <Navbar.Text> Tasks: <Link to='/notes'><Badge variant="danger">{todoStore.totalTodosCount()}</Badge> </Link></Navbar.Text>
                                              <Navbar.Text> &nbsp;Complted Tasks: <Link to='/notes'><Badge variant="success">{todoStore.completedTodosCount()}</Badge> </Link></Navbar.Text>
                                              <Navbar.Text> &nbsp;Notes: <Link to='/notes'><Badge variant="light">{noteStore.notesCount()}</Badge></Link></Navbar.Text>                
                                            
                                              <div>&nbsp;&nbsp;&nbsp;</div> 
                                              <Dropdown>
                                                <Dropdown.Toggle  className="btn btn-outline-light btn-sm" id="dropdown-basic">
                                                       <FaUserCircle></FaUserCircle> {user.name}
                                                </Dropdown.Toggle>

                                                <Dropdown.Menu>                                                        
                                                        <Dropdown.Item href="#/action-2" className="text-muted"> <FaCog></FaCog> &nbsp;&nbsp; Settings </Dropdown.Item>
                                                        <Dropdown.Item href="#/action-1" onClick={(e) => {e.preventDefault(); testApi();}} className="text-danger"> <FaCloud></FaCloud> &nbsp;&nbsp; Test API</Dropdown.Item>
                                                        <Dropdown.Item >&nbsp;&nbsp;&nbsp;&nbsp;<LogoutButton />&nbsp;&nbsp;</Dropdown.Item>
                                                </Dropdown.Menu>
                                                </Dropdown>                                     
                                            
                                              
      </Navbar.Collapse> : <LoginButton />}
              </Nav>
    
  );
});

export default AuthNav;