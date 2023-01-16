import Head from "next/head";
import Image from "next/image";
import { NextPage, GetServerSideProps } from "next";
import { useRouter } from "next/router";

import { getStory, Story } from "../../store/StoriesStore";
import StoryFull from "@/components/Stories/StoryFull";

interface Props {
  story: Story;
  error: string | null;
}

const StoryPage: NextPage<Props> = (props) => {
  const router = useRouter();
  const { pid } = router.query;

  return (
    <div>
      <Head>
        <title>RobertLynJA.com</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <main>
        <StoryFull story={props.story} />
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
        story: await getStory(context.params.id),
        error: null,
      },
    };
  } catch (error: any) {
    return {
      props: {
        story: null,
        error: error.message,
      },
    };
  }
};

export default StoryPage;
