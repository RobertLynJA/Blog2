export const API_ROOT = process.env.API_ROOT!;
export const AUTH0_AUDIENCE = process.env.AUTH0_AUDIENCE!;
export const AUTH0_SCOPE = process.env.AUTH0_SCOPE!; 
export const fetcher = (input: RequestInfo | URL, init? : RequestInit | undefined) => fetch(input, init).then(res => res.json());

var checkConfig = (name: string, config?: string) => {
  if (!config || config.trim().length === 0) {
    console.error(`${name} config value is not set`);
  }
}

checkConfig("API_ROOT", API_ROOT);
checkConfig("AUTH0_AUDIENCE", AUTH0_AUDIENCE);
checkConfig("AUTH0_SCOPE", AUTH0_SCOPE);