import React from 'react';
import AddToDoForm from '../components/ToDos/AddToDo';
import ToDosList from '../components/ToDos/ToDosList';


const ToDosView = () => {

    return ( 
        <React.Fragment>     
            <AddToDoForm/>
            <ToDosList/>
        </React.Fragment>
        );
};

export default ToDosView;