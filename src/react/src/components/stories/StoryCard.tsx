import ReactMarkdown from 'react-markdown'

export interface Story {
    id: string;
    title: string;
    content: string;
    publishedDate: string;
    encoding: string;
}

function StoryCard({ story }: { story: Story }) {
    let contentElement: React.ReactNode;

    switch (story.encoding) {
        case 'markdown':
            contentElement = (
                <div className="prose mt-2 text-gray-600">
                    <ReactMarkdown>{story.content}</ReactMarkdown>
                </div>
            );
            break;
        case 'text':
            contentElement = <p className="mt-2 text-gray-600 whitespace-pre-wrap">{story.content}</p>;
            break;
        default:
            contentElement = <p className="mt-2 text-gray-400 italic">Unknown content format</p>;
    }

    return (
        <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-200">
            <h2 className="text-xl font-semibold text-blue-600">{story.title}</h2>
            {contentElement}
            <p className="mt-4 text-xs text-gray-400">{new Date(story.publishedDate).toUTCString()}</p>
        </div>
    );
}

export default StoryCard
