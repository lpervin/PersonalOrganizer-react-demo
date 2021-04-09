
import { observable, action, autorun, makeAutoObservable } from 'mobx';
import { createContext } from "react";
import UserProfile from '../models/UserProfile';


export default class UserStore
{
   
    userProfile?: UserProfile | null;

    constructor(){
        makeAutoObservable(this);        
    }    

    @action getUser(){
            return window.localStorage.getItem('user');
    };


    @action getJWT(){
        return window.localStorage.getItem('jwt');
    };
}

const userStore = new UserStore();

autorun(async () => {
    
    if (userStore.userProfile!=null)
    {
           // const user = {name: userStore.userProfile.name!, email: userStore.userProfile.email!};
            // console.log('Add this token to Store', userStore.userProfile.accessToken);
            // console.log('Add this user to Store', userStore.userProfile.sub);
            window.localStorage.setItem('user', JSON.stringify(userStore.userProfile!));
            window.localStorage.setItem('jwt', userStore.userProfile.accessToken!);
    }
    else{   
            console.log('Remove JWT');         
            window.localStorage.removeItem('jwt');
            window.localStorage.removeItem('user');
    }    
});

export const UserStoreContext = createContext(userStore);