import { FunctionComponent } from "react";
import Link from "next/link";

import { Story } from "store/StoriesStore";

interface Props {
  story: Story;
}

const StorySummary: FunctionComponent<Props> = (props) => {
  return (
    <div style={{border:"1px solid black;"}}>
      <Link href={`/stories/${encodeURIComponent(props.story.id)}`}>
        {props.story.title}
      </Link>
      <div>{props.story.content}</div>
      <div>{new Date(props.story.publishedDate).toUTCString()}</div>
    </div>
  );
};

export default StorySummary;
