export const API_ROOT = process.env.NEXT_PUBLIC_API_ROOT!;
export const fetcher = (input: RequestInfo | URL, init? : RequestInit | undefined) => fetch(input, init).then(res => res.json());