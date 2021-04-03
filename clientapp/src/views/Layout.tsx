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
    //console.log(process.env.REACT_APP_API_URL);
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
              {/* <footer className="text-muted">{window.location.hostname}</footer>                   */}
         </React.Fragment>  );
};
export default Layout;

