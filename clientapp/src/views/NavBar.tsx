import React, { useContext} from "react"
import { observer } from "mobx-react-lite";
import { Nav, Navbar } from 'react-bootstrap';
import {RootStoreContext} from "../stores/RootStore";
import {ImHome} from 'react-icons/im';
import {Link} from "react-router-dom";

const NavBar = observer( () => {
    const store = useContext(RootStoreContext);  
    const noteStore = store.notesStore;
    const todoStore = store.todosStore;
    return (<Navbar bg="primary" variant="dark" sticky="top">
            <Navbar.Brand href="/home"><ImHome/></Navbar.Brand>
            <Nav className="mr-auto"  activeKey={window.location.pathname}>
                <Nav.Link href="/home">My ToDos</Nav.Link>
                <Nav.Link href="/notes">My Notes</Nav.Link>             
            </Nav>
            <Navbar.Text>
                # of Tasks: <Link to='/notes'>{todoStore.totalTodosCount()}</Link>
                # of Complted Tasks: <Link to='/notes'>{todoStore.completedTodosCount()}</Link>
                # of Notes: <Link to='/notes'>{noteStore.notesCount()}</Link>
            </Navbar.Text>
            </Navbar>);
});

export default NavBar;