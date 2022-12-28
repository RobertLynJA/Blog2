import Head from 'next/head'
import Image from 'next/image'
import axios from 'axios';
import { useEffect } from 'react';
import { GetStaticProps, GetStaticPaths, GetServerSideProps } from 'next'

type Story = {
  id: string,
  title: string,
  content: string,
  publishedDate: string
};

const Home: React.FC<{ stories: Story[], error: string }> = (props) => {

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

export default Home;

export const getServerSideProps: GetServerSideProps = async (context) => {
  let error: any = null;
  let result: any;

  try {
    result = await axios.get(process.env.API_ROOT + "/stories");
  } catch (err: any) {
    error = err.message;
  }

  return {
    props: {
      stories: result.data
    }, // will be passed to the page component as props
  }
}
