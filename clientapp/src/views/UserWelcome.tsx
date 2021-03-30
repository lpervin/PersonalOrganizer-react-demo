import { useAuth0 } from '@auth0/auth0-react';
import * as React from 'react';
import { Button, Jumbotron } from 'react-bootstrap';


const UserWelcome =  () => {

  const { loginWithRedirect } = useAuth0();

  return (
    <div>
      <Jumbotron>
          <h1>Welcome to Personal Organizer</h1>
          <p>&nbsp;</p>
          <div className="row">
            <div className="col-6">
              <p>
                If you are registered user Welcome back! Click login below.          
              </p>
            </div>
            <div className="col-6">
              <p>
                Otherwise please register below.          
              </p>
            </div>
          </div>
          <div className="row">
            <div className="col-6">              
              <Button variant="success"  onClick={() => loginWithRedirect()}>Log In</Button>              
            </div>
            <div className="col-6">              
                <Button variant="success"  onClick={() =>
        loginWithRedirect({
          screen_hint: "signup",
        })
      }
      >Sign Up</Button>                 
            </div>
          </div>          
</Jumbotron>
    </div>
  );
}

export default UserWelcome;
