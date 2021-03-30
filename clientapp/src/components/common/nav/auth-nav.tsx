import * as React from 'react';
import { Badge, Nav, Navbar } from 'react-bootstrap';
import { useAuth0 } from "@auth0/auth0-react";
import { observer } from "mobx-react-lite";
import LoginButton from '../login-button';
import LogoutButton from '../logout-button';
import {ImSpinner3} from 'react-icons/im'
import { Link } from 'react-router-dom';
import { RootStoreContext } from '../../../stores/RootStore';
import  Loading  from '../Loading'


const AuthNav = observer( () => {
    
    const { isAuthenticated } = useAuth0();
    const { isLoading } = useAuth0();

    const store = React.useContext(RootStoreContext);  
    const noteStore = store.notesStore;
    const todoStore = store.todosStore;

    console.log(isLoading);
    if (isLoading) {
            return <Loading className='text-danger'></Loading>;
    }
    

    return (    
              <Nav className="mr-md-0">                
                  {isAuthenticated ?   <Navbar.Collapse className="justify-content-end">
                                              <Navbar.Text> Tasks: <Link to='/notes'><Badge variant="danger">{todoStore.totalTodosCount()}</Badge> </Link></Navbar.Text>
                                              <Navbar.Text> &nbsp;Complted Tasks: <Link to='/notes'><Badge variant="success">{todoStore.completedTodosCount()}</Badge> </Link></Navbar.Text>
                                              <Navbar.Text> &nbsp;Notes: <Link to='/notes'><Badge variant="light">{noteStore.notesCount()}</Badge></Link></Navbar.Text>                
                                              <div>&nbsp;&nbsp;&nbsp;</div>
                                              <LogoutButton />
      </Navbar.Collapse> : <LoginButton />}
              </Nav>
    
  );
});

export default AuthNav;