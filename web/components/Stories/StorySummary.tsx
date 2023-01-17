import { FunctionComponent } from "react";
import Link from "next/link";
import ReactMarkdown from "react-markdown";

import { Story } from "store/StoriesStore";

interface Props {
  story: Story;
}

const StorySummary: FunctionComponent<Props> = (props) => {
  return (
    <div style={{ border: "1px solid black" }}>
      <div>
        <Link href={`/stories/${encodeURIComponent(props.story.id)}`}>
          {props.story.title}
        </Link>
      </div>
      <div>
        <ReactMarkdown children={props.story.content} />
      </div>
      <div>{new Date(props.story.publishedDate).toUTCString()}</div>
    </div>
  );
};

export default StorySummary;
