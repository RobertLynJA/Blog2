import Head from 'next/head'
import Image from 'next/image'

import styles from '@/pages/index.module.css'

export default function Home() {
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
      </main>

      <footer>
      </footer>
    </div>
  )
}
