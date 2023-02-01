import "@/styles/global.css";
import type { AppProps } from "next/app";
import { UserProvider } from "@auth0/nextjs-auth0/client";

import Layout from "@/components/UI/Layout";

export default function MyApp({ Component, pageProps }: AppProps) {
  return (
    <UserProvider>
      <Layout>
        <Component {...pageProps} />
      </Layout>
    </UserProvider>
  );
}
