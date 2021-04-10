import { useAuth0 } from '@auth0/auth0-react';
import * as React from 'react';
import Loading from '../components/common/Loading';
import ToDosView from './ToDosView';
import UserWelcome from './UserWelcome';



const Home =  () => {

    const { isAuthenticated,isLoading } = useAuth0();

    if (isLoading) {
      return <Loading className='text-danger'></Loading>;
  }
  
  return (
    <div>
      { isAuthenticated ? <ToDosView></ToDosView> : <UserWelcome></UserWelcome>}
    </div>
  );
}

export default Home;
