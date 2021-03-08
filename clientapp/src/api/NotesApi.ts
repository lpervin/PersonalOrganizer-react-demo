import axios from 'axios';
import Note from '../models/Note';
import {requests, responseBody} from './ApiClient'

const NotesApi = { //params: URLSearchParams
    list: (): Promise<Note[]> => axios.get('/notes').then(responseBody),

    details: (id: string) => requests.get(`/notes/${id}`),

    create: (note: Note) => requests.post('/notes', note),

    update: (note: Note) =>  requests.put('/notes', note),

    delete: (id: number) => requests.del(`/notes/${id.toString()}`) 
  
};

export default NotesApi;