import axios, { AxiosResponse } from "axios";

import { API_ROOT, fetcher } from "./defaults";
import ErrorLogger from "./ErrorLogger";

export interface Story {
  id: string;
  title: string;
  content: string;
  publishedDate: string;
  encoding: string;
}

const x = {
  name: "Robert",
  country: "USA"
};

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

export const getStory = async (id: string) => {
  const url = `${API_ROOT}/api/Stories/${encodeURIComponent(id)}`;

  try {
    const { data } = await axios.get<Story>(url);
    return data;
  } catch (error: any) {
    if (axios.isAxiosError(error)) {
      if (error.response?.status === 404) {
        return null;
      }
    }

    ErrorLogger(url, error);
    throw new Error(error.message);
  }
};
