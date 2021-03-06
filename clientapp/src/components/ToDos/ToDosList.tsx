import React from 'react';
import { useContext } from 'react';
import { observer } from "mobx-react-lite";
import {RootStoreContext} from "../../stores/RootStore";
import { Button, Spinner, Table } from 'react-bootstrap';
import {BsCheckCircle} from 'react-icons/bs'
import {TiDeleteOutline} from 'react-icons/ti'
import { AuthenticationContext } from '../../stores/UserAuthStore';
import ToDo from '../../models/ToDo';
import Loading from '../common/Loading';

const ToDosList = observer( () => {

    const rootStore = useContext(RootStoreContext);   
    const todoStore = rootStore.todosStore;
    const authContext = useContext(AuthenticationContext);

    if (!authContext.isUserAuthenticated)
    {
        return <Loading/>;
    }


    const todos = todoStore.getAllToDos();
    const handleDelete = async (id:number) => {
                await todoStore.Delete(id);
    };

    const handleUpdate = async (e:React.MouseEvent<HTMLAnchorElement>,todo: ToDo) => {
        e.preventDefault();
        todo.isCompleted = !todo.isCompleted;
        todo.dateCompleted = todo.isCompleted ? new Date() : todo.dateCompleted;
        await todoStore.updateToDo(todo);
    }
    return (<React.Fragment>

            {(todos==null) ? (<Spinner animation="border" role="status">
            <span className="sr-only">Loading...</span>
            </Spinner>) : <></> }

                  <Table responsive>
                        <tbody>                              
                                {todos?.map((t) => (
                            
                                    <tr key={t.id}>
                                        <td className="pull-left">
                                                {t.description}
                                        </td>                            
                                    
                                        <td>
                                            <div className="pull-left todo-icons">
                                                <a href="#" onClick={(e) => handleUpdate(e, t)}>
                                                            {t.isCompleted ? <BsCheckCircle className="text-success"/> : <TiDeleteOutline className="text-danger" />}
                                                </a> 
                                            </div>                                    
                                        </td>
                                        <td>
                                        <button className="btn btn-danger btn-sm" onClick={() => handleDelete(t.id!)}>Delete</button>
                                        </td>     
                                    </tr>
                                    )) }    
                            </tbody>
                            </Table>     
                   
                
    </React.Fragment>);
});

export default ToDosList;