import Head from "next/head";
import Image from "next/image";
import { NextPage, GetServerSideProps } from "next";

import { getStoriesByDate, Story } from "../store/StoriesStore";
import StorySummary from "@/components/Stories/StorySummary";

interface Props {
  stories: Story[];
}

export const getServerSideProps: GetServerSideProps<Props> = async (
  context
) => {
  return {
    props: {
      stories: await getStoriesByDate(20, 0),
      error: null,
    },
  };
};

const Home: NextPage<Props> = (props) => {
  return (
    <div>
      <main>
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

export default Home;
