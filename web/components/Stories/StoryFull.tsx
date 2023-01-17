import { FunctionComponent } from 'react';
import ReactMarkdown from "react-markdown";

import { Story } from 'store/StoriesStore';

interface Props {
  story: Story;
}

const StoryFull : FunctionComponent<Props> = props => {
  return (
    <div>
    <div>
      {props.story.title}
    </div>
    <div>
      <ReactMarkdown children={props.story.content} />
    </div>
    <div>{new Date(props.story.publishedDate).toUTCString()}</div>
  </div>
  );
};

export default StoryFull;