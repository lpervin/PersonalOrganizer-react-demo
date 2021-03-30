import { withAuthenticationRequired } from '@auth0/auth0-react';
import * as React from 'react';
import { Route } from 'react-router-dom';
import Loading from '../components/common/Loading';

export interface IRoute {
    component: React.ComponentType<{}> ;
    path:string;
    args?: {} | undefined;
}


const ProtectedRoute = ({ component, path, ...args }: IRoute) => (
    <Route path={path}
      component={withAuthenticationRequired(component, {
        onRedirecting: () => <Loading />,
      })}
      {...args}
    />
  );
  
  export default ProtectedRoute;
