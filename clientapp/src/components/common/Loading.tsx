import { ImSpinner3 } from 'react-icons/im';

export interface ILoadingOptions {  
  className?:string | undefined;
}

const Loading = ({className}: ILoadingOptions) =>  {
  className = className ? className : 'text-primary'
  return (
    <div>
      <ImSpinner3 className={className}></ImSpinner3>
    </div>
  );
}

export default Loading;