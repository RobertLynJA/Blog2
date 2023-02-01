import { NextPage, GetServerSideProps } from "next";
import { useUser } from '@auth0/nextjs-auth0/client';

interface Props {}

const Admin: NextPage<Props> = (props) => {
  const { user, error, isLoading } = useUser();

  if (isLoading) return <div>Loading...</div>;
  if (error) return <div>{error.message}</div>;

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

export default Admin;
