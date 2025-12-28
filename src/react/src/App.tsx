import { useState, useEffect } from 'react'

interface Story {
    id: string;
    title: string;
    summary: string;
}

function App() {
    const [stories, setStories] = useState<Story[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const apiRoot = import.meta.env.VITE_API_ROOT;

        fetch(`${apiRoot}/api/stories`) // Adjust endpoint as needed
            .then(res => res.json())
            .then(data => {
                setStories(data);
                setLoading(false);
            })
            .catch(err => {
                console.error("Failed to fetch stories", err);
                setLoading(false);
            });
    }, []);

    return (
        <div className="min-h-screen bg-gray-50 p-8">
            <main className="max-w-4xl mx-auto">
                <h1 className="text-3xl font-bold mb-8 text-gray-900">Latest Stories</h1>

                {loading ? (
                    <p className="text-gray-500 text-center">Loading stories...</p>
                ) : (
                    <div className="grid gap-6">
                        {stories?.map((story) => (
                            <div key={story.id} className="bg-white p-6 rounded-lg shadow-sm border border-gray-200">
                                <h2 className="text-xl font-semibold text-blue-600 hover:underline cursor-pointer">
                                    {story.title}
                                </h2>
                                <p className="mt-2 text-gray-600">{story.summary}</p>
                            </div>
                        ))}
                    </div>
                )}
            </main>
            <footer className="mt-12 text-center text-gray-400 text-sm">
                &copy; {new Date().getFullYear()} My Blog
            </footer>
        </div>
    )
}

export default App
