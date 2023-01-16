import { ReactNode, FunctionComponent } from "react";
import CookieConsent from "react-cookie-consent";

interface Props {
  children: ReactNode;
}

const Layout: FunctionComponent<Props> = (props) => {
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
