import React, { FunctionComponent } from "react";
import Link from "next/link";

import { Story } from "store/StoriesStore";
import StoryContent from "./StoryContent";

interface Props {
  story: Story;
}

const StorySummary: FunctionComponent<Props> = (props) => {
  return (
    <div>
      <div>
        <Link
          href={`/stories/${encodeURIComponent(props.story.id)}`}
          className="text-xl"
        >
          {props.story.title}
        </Link>
      </div>
      <StoryContent
        content={props.story.content}
        encoding={props.story.encoding}
      />
      <div className="text-sm">
        {new Date(props.story.publishedDate).toUTCString()}
      </div>
    </div>
  );
};

export default React.memo(StorySummary);
