import React, { useContext, useState } from 'react';
import { observer } from "mobx-react-lite";
import { Button, Form } from 'react-bootstrap';
import {RootStoreContext} from "../../stores/RootStore";

const AddNote = observer( () => {
        
    const rootStore = useContext(RootStoreContext);   
    const noteStore = rootStore.notesStore;
        const [noteText, SetNoteText] = useState("");

        const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
                SetNoteText(event.currentTarget.value);
        };

        const handleSubmit = (e: React.SyntheticEvent) => {
            e.preventDefault();
            noteStore?.addNote(noteText);
            SetNoteText('');
        };

        return (<React.Fragment>
                    <Form onSubmit={handleSubmit}>  
                            <Form.Group controlId="from.ControlTextarea1">
                                <Form.Label>What's on your mind</Form.Label>
                                <Form.Control 
                                as="textarea" 
                                rows={3} 
                                value={noteText}
                                onChange={handleChange}
                                />
                            </Form.Group>
                            <Button variant="primary" type="submit">
                                Add
                            </Button>
                        </Form>
                </React.Fragment>
                );
        });

export default AddNote;