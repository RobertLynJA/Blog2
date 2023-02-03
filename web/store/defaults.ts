export const API_ROOT = process.env.API_ROOT!;
export const AUTH0_AUDIENCE = process.env.AUTH0_AUDIENCE!;
export const AUTH0_SCOPE = process.env.AUTH0_SCOPE!; 
export const fetcher = (input: RequestInfo | URL, init? : RequestInit | undefined) => fetch(input, init).then(res => res.json());
