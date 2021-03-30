import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import  {RootStoreContext, RootStore } from './stores/RootStore';
import Layout from './views/Layout';

function App() {
  return (
    <div className="App">
      <RootStoreContext.Provider value={new RootStore()}>     
              <Layout></Layout>                   
      </RootStoreContext.Provider>   
      
     </div>
  );
}

export default App;
