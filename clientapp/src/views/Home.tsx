import { useAuth0 } from '@auth0/auth0-react';
import * as React from 'react';
import ToDosView from './ToDosView';
import UserWelcome from './UserWelcome';



const Home =  () => {

    const { isAuthenticated } = useAuth0();

  return (
    <div>
      { isAuthenticated ? <ToDosView></ToDosView> : <UserWelcome></UserWelcome>}
    </div>
  );
}

export default Home;
