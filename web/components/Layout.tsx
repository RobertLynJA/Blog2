import { NextPage } from "next";
import { ReactNode } from "react";
import CookieConsent from "react-cookie-consent";

interface Props {
  children: ReactNode;
}

const Layout: NextPage<Props> = (props) => {
  return (
    <>
      {props.children}
      <CookieConsent>
        This website uses cookies to enhance the user experience.
      </CookieConsent>
    </>
  );
};

export default Layout;
