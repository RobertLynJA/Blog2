import Head from "next/head";
import { ReactNode, FunctionComponent } from "react";
import CookieConsent from "react-cookie-consent";

interface Props {
  children: ReactNode;
  className?: string;
}

const Layout: FunctionComponent<Props> = (props) => {
  const className = props.className || "";

  return (
    <div className={`container mx-auto px-8 py-8 ${className}`}>
      <Head>
        <title>RobertLynJA.com</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <h1 className="text-3xl pb-8">Welcome to RobertLynJA.com</h1>
      {props.children}
      <CookieConsent>
        This website uses cookies to enhance the user experience.
      </CookieConsent>
    </div>
  );
};

export default Layout;
