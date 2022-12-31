const ErrorLogger = (...args: string[]) : void => {
    console.error(`[${args.join("--")}]` );
}

export default ErrorLogger;