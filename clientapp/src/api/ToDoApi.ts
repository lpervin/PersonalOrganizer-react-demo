import ToDo from '../models/ToDo';
import {requests} from './ApiClient'

const apiUrl = '/todo';
const ToDosApi = {
    list: (): Promise<ToDo[]> => requests.get(apiUrl),

    details: (id: string) => requests.get(`${apiUrl}/${id}`),

    create: (note: ToDo) => requests.post(apiUrl, note),

    update: (note: ToDo) =>  requests.put(apiUrl, note),

    delete: (id: number) => requests.del(`${apiUrl}/${id.toString()}`)  ,

    test: (): Promise<string> => requests.get(`${apiUrl}/private`)
};

export default ToDosApi;