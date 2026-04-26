import { useState, useEffect } from 'react'
import StoryCard, { type Story } from '../components/stories/StoryCard'

export default function HomePage() {
    const [stories, setStories] = useState<Story[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const apiRoot = import.meta.env.VITE_API_ROOT;

        fetch(`${apiRoot}/api/stories`)
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
        <>
            {loading ? (
                <p className="text-gray-500 text-center">Loading stories...</p>
            ) : (
                <div className="grid gap-6">
                    {stories?.map((story) => (
                        <StoryCard key={story.id} story={story} />
                    ))}
                </div>
            )}
        </>
    )
}
