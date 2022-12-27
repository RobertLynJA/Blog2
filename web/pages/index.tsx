import Head from 'next/head'
import Image from 'next/image'
import axios from 'axios';
import { useEffect } from 'react';
import { GetStaticProps, GetStaticPaths, GetServerSideProps } from 'next'

import styles from '@/pages/index.module.css'

type Temperature = {
  temperatureC: string;
  date: string;
};

const Home: React.FC<{ test: Temperature[], error: string }> = (props) => {

  console.log(props.test);

  return (
    <div>
      <Head>
        <title>Create Next App</title>
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
          {props.test?.map(item => <div key={item.date}>
            {item.temperatureC}
          </div>)}
        </div>
        <div>
          { props.error }
        </div>
      </main>

      <footer>
      </footer>
    </div>
  )
};

export default Home;

export const getServerSideProps: GetServerSideProps = async (context) => {
  context.res.setHeader(
    'Cache-Control',
    'public, s-maxage=60, stale-while-revalidate=3600'
  )

  let error: any = null;
  let result: any;

  try {
    result = await axios.get(process.env.API_ROOT + "/weatherforecast");
  } catch (err: any) {
    error = err.message;
  }

  return {
    props: {
      test: error ? [] : result.data,
      error: error
    }, // will be passed to the page component as props
  }
}