import axios from 'axios';
import ToDo from '../models/ToDo';
import {requests, responseBody} from './ApiClient'

const apiUrl = '/todo';
const ToDosApi = {
    list: (): Promise<ToDo[]> => axios.get(apiUrl).then(responseBody),

    details: (id: string) => requests.get(`${apiUrl}/${id}`),

    create: (note: ToDo) => requests.post(apiUrl, note),

    update: (note: ToDo) =>  requests.put(apiUrl, note),

    delete: (id: number) => requests.del(`${apiUrl}/${id.toString()}`)   
};

export default ToDosApi;