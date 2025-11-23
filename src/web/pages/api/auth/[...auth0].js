// pages/api/auth/[...auth0].js
import { handleAuth, handleLogin } from '@auth0/nextjs-auth0';

import { AUTH0_AUDIENCE, AUTH0_SCOPE } from '../../../store/defaults';

export default handleAuth({
  login: handleLogin({
    authorizationParams: {
      audience: AUTH0_AUDIENCE,
      // Add the `offline_access` scope to also get a Refresh Token
      scope: AUTH0_SCOPE 
    }
  })
});
