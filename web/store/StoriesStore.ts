import axios, { AxiosResponse } from "axios";

import { API_ROOT } from "./defaults";
import ErrorLogger from "./ErrorLogger";

export interface Story {
  id: string;
  title: string;
  content: string;
  publishedDate: string;
}

export const getStoriesByDate = async (pageSize: number, page: number) => {
  const url = `${API_ROOT}/api/Stories/ByDate?pageSize=${pageSize}&page=${page}`;

  try {
    const { data } = await axios.get<Story[]>(url);
    return data;
  } catch (error: any) {
    ErrorLogger(url, error);
    throw new Error(error.message);
  }
};
