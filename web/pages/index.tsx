import Head from 'next/head'
import Image from 'next/image'
import axios from 'axios';

import { NextPage, GetServerSideProps } from 'next'

interface Props {
  stories: Story[];
  error: string;
}

interface Story {
  id: string,
  title: string,
  content: string,
  publishedDate: string
};

const Home: NextPage<Props> = (props) => {

  console.log(props.stories);

  return (
    <div>
      <Head>
        <title>RobertLynJA.com</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <main>
        <h1 className="text-3xl">
          Hello from <a href="https://nextjs.org">Next.js</a> and <a href="https://tailwindcss.com/">Tailwind</a>
        </h1>

        <h2>
          Ignore random test data:
        </h2>
        <div>
          {props.stories?.map(item => <div key={item.id}>
            {item.content} - {(new Date(item.publishedDate).toString())}
          </div>)}
        </div>
        <div>
          {props.error}
        </div>
      </main>

      <footer>
      </footer>
    </div>
  )
};

export const getServerSideProps: GetServerSideProps<Props> = async (context) => {
  let error: any = null;
  let result: any;

  try {
    result = await axios.get(process.env.API_ROOT + "/stories");
  } catch (err: any) {
    error = err.message;
  }

  return {
    props: {
      stories: result.data as Story[],
      error: error
    },
  }
}

export default Home;