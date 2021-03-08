import NavBar from './NavBar';
import NotesView from './NotesView';
import ToDosView from './ToDosView';
import React from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route
  } from 'react-router-dom';


const  Layout = () => {
    return (<React.Fragment>  
            <Router>                 
                <NavBar></NavBar>
                    <div className="app-content">
                        <Switch>
                            <Route path="/home">
                                <ToDosView />
                            </Route>
                            <Route path="/notes">
                                <NotesView/>
                            </Route>
                            <Route path="/">
                                <ToDosView />
                            </Route>
                        </Switch>                        
                    </div>          
              </Router>                   
         </React.Fragment>  );
};
export default Layout;

