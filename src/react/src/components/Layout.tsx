import { Link } from 'react-router-dom'
import type { ReactNode } from 'react'

export default function Layout({ children }: { children: ReactNode }) {
    return (
        <div className="min-h-screen bg-gray-50 p-8">
            <header className="max-w-4xl mx-auto mb-8">
                <Link to="/" className="text-3xl font-bold text-gray-900 hover:text-gray-700">
                    RobertLynJA.com
                </Link>
                <nav className="mt-2 flex gap-4 text-sm text-gray-500">
                    <Link to="/" className="hover:text-gray-900">Home</Link>
                    <Link to="/about" className="hover:text-gray-900">About</Link>
                </nav>
            </header>
            <main className="max-w-4xl mx-auto">
                {children}
            </main>
            <footer className="mt-12 text-center text-gray-400 text-sm">
                &copy; {new Date().getFullYear()} RobertLynJA.com
            </footer>
        </div>
    )
}
