
import { action, autorun, makeAutoObservable, computed } from 'mobx';
import { createContext } from "react";
import UserProfile from '../models/UserProfile';


export default class UserAuthStore
{
   
    userProfile?: UserProfile | null;

    constructor(){
        makeAutoObservable(this);        
    }    
    
    @computed isUserAuthenticated(){
        return this.userProfile!=null;
    }

    @action getUserId(){
            if (this.userProfile==null)
                return null;

            return this.userProfile.sub;
    };


    @action getJWT(){
        return window.localStorage.getItem('jwt');
    };
}

const userStore = new UserAuthStore();

autorun(async () => {
    
    if (userStore.userProfile!=null)
    {
           // const user = {name: userStore.userProfile.name!, email: userStore.userProfile.email!};
            // console.log('Add this token to Store', userStore.userProfile.accessToken);
            
            //console.log('Add this user sub to Store', userStore.userProfile.sub);
            //console.log('Add JWT');    
            window.localStorage.setItem('user', JSON.stringify(userStore.userProfile!));
            window.localStorage.setItem('jwt', userStore.userProfile.accessToken!);
    }
    else{   
            console.log('Remove JWT');         
            window.localStorage.removeItem('jwt');
            window.localStorage.removeItem('user');
    }    
});

export const AuthenticationContext = createContext(userStore);