import Head from "next/head";
import Image from "next/image";
import { NextPage, GetServerSideProps } from "next";

import { getStoriesByDate, Story } from "../store/StoriesStore";

interface Props {
  stories: Story[];
  error: string | null;
}

const Home: NextPage<Props> = (props) => {
  return (
    <div>
      <Head>
        <title>RobertLynJA.com</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <main>
        <h1 className="text-3xl">
          Hello from <a href="https://nextjs.org">Next.js</a> and{" "}
          <a href="https://tailwindcss.com/">Tailwind</a>
        </h1>

        <h2>Ignore random test data:</h2>
        <div>
          {props.stories?.map((item) => (
            <div key={item.id}>
              {item.content} - {new Date(item.publishedDate).toString()}
            </div>
          ))}
        </div>
        <div>{props.error}</div>
      </main>

      <footer></footer>
    </div>
  );
};

export const getServerSideProps: GetServerSideProps<Props> = async (
  context
) => {
  try {
    return {
      props: {
        stories: await getStoriesByDate(0, 20),
        error: null,
      },
    };
  } catch (error: any) {
    return {
      props: {
        stories: [],
        error: error.message,
      },
    };
  }
};

export default Home;
