
import { observer } from "mobx-react-lite";
import { Badge, Nav, Navbar } from 'react-bootstrap';

import {ImHome} from 'react-icons/im';
import {Link} from "react-router-dom";
import AuthNav from '../components/common/nav/auth-nav';

// import LoginButton from '../components/common/login-button';
// import LogoutButton from '../components/common/logout-button';

export default function NavBar() {

   // console.log(isAuthenticated);
    const selectedPath = window.location.pathname==='/' ? '/home' : window.location.pathname;
   // console.log(window.location.pathname);
    return (<Navbar bg="primary" variant="dark" sticky="top">
                <Navbar.Brand href="/home"><ImHome/></Navbar.Brand>
                <Nav className="mr-auto"  activeKey={selectedPath}>
                    <Nav.Link href="/home">My ToDos</Nav.Link>
                    <Nav.Link href="/notes">My Notes</Nav.Link>             
                </Nav>      
                <AuthNav/>                       
            </Navbar>);
};
