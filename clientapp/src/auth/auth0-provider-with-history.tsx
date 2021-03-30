
import React from "react";
import { useHistory } from "react-router-dom";
import { AppState, Auth0Provider } from "@auth0/auth0-react";
import { ReactNode } from "react";

interface IProps {
  children: ReactNode;  
}

const Auth0ProviderWithHistory = ({ children }: IProps) => {
  const history = useHistory();
  const domain:string = process.env.REACT_APP_AUTH0_DOMAIN!;
  const clientId:string = process.env.REACT_APP_AUTH0_CLIENT_ID!;
  const audience = process.env.REACT_APP_AUTH0_AUDIENCE;

  const onRedirectCallback = (appState:AppState) => {
    history.push(appState?.returnTo || window.location.pathname);
  };

  return (
    <Auth0Provider
      domain={domain}
      clientId={clientId}
      redirectUri={window.location.origin}
      onRedirectCallback={onRedirectCallback}
      audience={audience}
    >
      {children}
    </Auth0Provider>
  );
};

export default Auth0ProviderWithHistory;
