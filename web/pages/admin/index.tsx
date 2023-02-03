import { NextPage, GetServerSideProps } from "next";
import { useUser } from '@auth0/nextjs-auth0/client';
import useSWR from 'swr';
import { fetcher } from "store/defaults";

import auth0, { withPageAuthRequired } from '@auth0/nextjs-auth0';

interface Props {}

const Admin: NextPage<Props> = (props) => {
  const { user, error, isLoading } = useUser();
  const result = useSWR('/api/admin/protected', fetcher);

  console.log("DATA");
  console.log(result.data);

  if (isLoading) return <div>Loading...</div>;
  if (error) return <div>{error.message}</div>;

  console.log(user);

  const userData = (
    user && (
      <div>
        <img src={user.picture!} alt={user.name!} />
        <h2>{user.name}</h2>
        <p>{user.email}</p>
      </div>
    ));

  return (
    <div>
      <main>
        <div>
          {!user && <a href="/api/auth/login">Login</a>}
          {user && <a href="/api/auth/logout">Logout</a>}
        </div>
        <div>
          {userData}
        </div>
      </main>

      <footer></footer>
    </div>
  );
};

export const getServerSideProps = withPageAuthRequired();
export default Admin;
