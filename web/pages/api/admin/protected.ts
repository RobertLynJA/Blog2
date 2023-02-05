import { withApiAuthRequired, getSession, getAccessToken } from '@auth0/nextjs-auth0';

import { testUser, testAdmin } from 'store/StoriesStore';

export default withApiAuthRequired(async function myApiRoute(req, res) {
  const { accessToken } = await getAccessToken(req, res, {
    scopes: ['write:stories']
  });
  
  console.log("Access Token: " + accessToken);

  const getUser = await testUser(accessToken!);
  const getAdmin = await testAdmin(accessToken!);

  const { user } = await getSession(req, res);
  res.json({ protected: 'My Secret', id: user.sub, user: getUser, admin: getAdmin});
});