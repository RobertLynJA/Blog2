import axios, { AxiosResponse } from 'axios';

import { API_ROOT } from './defaults';
import ErrorLogger from './ErrorLogger';

export interface Story {
    id: string;
    title: string;
    content: string;
    publishedDate: string;
}

export const getStoriesByDate = async (pageSize: number, page: number) => {
    try
    {
        const { data } = await axios.get<Story[]>(`${API_ROOT}/api/Stories/ByDate?pageSize=${pageSize}&page=${page}`);
        return data;
    } catch (error : any) {
        if (axios.isAxiosError(error)) {
            //handleAxiosError(error);
          } else   { 
            //handleUnexpectedError(error);
          }
        ErrorLogger(error.message);
        throw new Error(error.message);
    }
}