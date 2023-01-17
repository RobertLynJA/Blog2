import Head from "next/head";
import Image from "next/image";
import { NextPage, GetServerSideProps } from "next";

import { getStoriesByDate, Story } from "../store/StoriesStore";
import StorySummary from "@/components/Stories/StorySummary";

interface Props {
  stories: Story[];
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

        <div>
          {props.stories?.map((item) => (
            <StorySummary story={item} key={item.id} />
          ))}
        </div>
      </main>

      <footer></footer>
    </div>
  );
};

export const getServerSideProps: GetServerSideProps<Props> = async (
  context
) => {
  return {
    props: {
      stories: await getStoriesByDate(0, 20),
      error: null,
    },
  };
};

export default Home;
