import NavBar from './NavBar';
import NotesView from './NotesView';
import ToDosView from './ToDosView';
import React from 'react';
import Auth0ProviderWithHistory from "../auth/auth0-provider-with-history"; 
import ProtectedRoute from "../auth/protected-route";
import Home from './Home';

import {
    BrowserRouter as Router,
    Switch,
    Route
  } from 'react-router-dom';



const  Layout = () => {
    //console.log(process.env.REACT_APP_API_URL);
    return (<React.Fragment>  
            <Router>      
            <Auth0ProviderWithHistory>            
                <NavBar></NavBar>
                    <div className="app-content">
                        <Switch>
                            
                            <ProtectedRoute path="/home" component={Home}></ProtectedRoute>
                            <ProtectedRoute path="/notes" component={NotesView}></ProtectedRoute>
                            <ProtectedRoute path="/todos" component={ToDosView}></ProtectedRoute>
                            <Route path="/">
                                <Home />
                            </Route>
                        </Switch>                        
                    </div>  
                    </Auth0ProviderWithHistory>         
              </Router> 
              {/* <footer className="text-muted">{window.location.hostname}</footer>                   */}
         </React.Fragment>  );
};
export default Layout;

