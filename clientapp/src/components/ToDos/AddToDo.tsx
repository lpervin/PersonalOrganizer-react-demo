import React, { useContext, useState } from 'react';
import { observer } from "mobx-react-lite";
import { Button, Col, Form, Row } from 'react-bootstrap';
import {RootStoreContext} from "../../stores/RootStore";
import ToDo from '../../models/ToDo';


const AddToDoForm = observer(()=> 
{
    const rootStore = useContext(RootStoreContext);
    const todoStore = rootStore.todosStore;
    const [todoText, setToDoText] = useState('');
    const [isCompleted, setIsCompleted] = useState(false);
    const toggleCompleted = () => {
        const completedState = !isCompleted;
        setIsCompleted(completedState);
    };

    const handleChange = (e:React.ChangeEvent<HTMLInputElement>) => {
        setToDoText(e.currentTarget.value);
    };

    const handleSubmit = (e: React.SyntheticEvent) => {
            e.preventDefault();
            todoStore.AddToDo({ description: todoText, isCompleted: isCompleted,
                                dateCreated: new Date(),
                                dateCompleted: isCompleted ? new Date() : null
            } as ToDo);
            setIsCompleted(false);
            setToDoText('');

    };
        return (<React.Fragment>
                            <Form onSubmit={handleSubmit}>
                                    <Form.Row>
                                        <Form.Group as={Col} controlId="formGridText">
                                            
                                            <Form.Control as="textarea" 
                                            placeholder="Enter something you'd like to do"  
                                            value={todoText}
                                            onChange={handleChange}
                                            />
                                          </Form.Group>
                                          <Form.Group as={Col} controlId="formGridCity" >
                                          
                                          <div className="pull-left">
                                                <Form.Check type="checkbox" 
                                                label="Completed"
                                                checked={isCompleted}
                                                onChange={toggleCompleted}
                                                />
                                          </div>
                                                
                                          </Form.Group>                                        
                                    </Form.Row>


                                    <Form.Row>
                                  

                                        <Form.Group as={Col} controlId="formGridState">
                                            <div className="pull-left">
                                                    <Button  variant="primary" type="submit">
                                                    Submit
                                                </Button>                                        
                                            </div>
                                                
                                        </Form.Group>

                                    </Form.Row>

                                 

                                    </Form>
                
                

        </React.Fragment>);
});

export default AddToDoForm;