import { withApiAuthRequired, getSession, getAccessToken } from '@auth0/nextjs-auth0';

export default withApiAuthRequired(async function myApiRoute(req, res) {
  const { accessToken } = await getAccessToken(req, res, {
    scopes: ['write:stories']
  });
  
  console.log(accessToken);

  const { user } = await getSession(req, res);
  res.json({ protected: 'My Secret', id: user.sub });
});