---json
{
  "documentId": 0,
  "title": "flippant remarks about BehaviorSubject",
  "documentShortName": "2019-02-25-flippant-remarks-about-behaviorsubject",
  "fileName": "index.html",
  "path": "./entry/2019-02-25-flippant-remarks-about-behaviorsubject",
  "date": "2019-02-26T02:57:33.452Z",
  "modificationDate": "2019-02-26T02:57:33.452Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2019-02-25-flippant-remarks-about-behaviorsubject",
  "tag": "{\r\n  \"extract\": \"It feels like BehaviorSubject was built to make observable store services possible. BehaviorSubject is at the heart of the possibility of never needing a large/complex package like Redux—ever. In “State management in Angular with observable store service...\"\r\n}"
}
---

# flippant remarks about BehaviorSubject

It *feels* like `BehaviorSubject` was built to make *observable store services* possible. `BehaviorSubject` is at the heart of the possibility of never needing a large/complex package like [Redux](https://redux.js.org/)—*ever*. In “[State management in Angular with observable store services](https://jurebajt.com/state-management-in-angular-with-observable-store-services/),” Jure Bajt writes:

<blockquote>

…we used the ideas from Redux to create a state management solution that leverages Angular’s (and RxJS’s) features to do its job…

</blockquote>

Jure Bajt developed `rxjs-observable-store` [[GitHub](https://github.com/jurebajt/rxjs-observable-store)] to avoid “pitfall # 1” in “[How to build Angular apps using Observable Data Services - Pitfalls to avoid](https://blog.angular-university.io/how-to-build-angular2-apps-using-rxjs-observable-data-services-pitfalls-to-avoid/)”:

<blockquote>

…we don’t expose the subject directly to store clients, instead, we expose an observable… Exposing the subject directly could lead to event soup applications, where events get chained together in a hard to reason way.

</blockquote>

To avoid the overhead of managing Bajt’s offering as a package, [this](https://github.com/jurebajt/rxjs-observable-store/blob/master/src/store.ts) is the essential:

import {Observable, BehaviorSubject} from 'rxjs';

export class Store&lt;T&gt; {
            state$: Observable&lt;T&gt;;
            private _state$: BehaviorSubject&lt;T&gt;;

protected constructor (initialState: T) {
                this._state$ = new BehaviorSubject(initialState);
                this.state$ = this._state$.asObservable();
            }

get state (): T {
                return this._state$.getValue();
            }

setState (nextState: T): void {
                this._state$.next(nextState);
            }
        }

## no, really: what about Redux and ngrx?

Jure Bajt addresses those that recommend [Redux](https://redux.js.org/):

<blockquote>

The solution we developed is a really stripped down version of Redux. It does not “prescribe” how to handle async actions, how to combine reducers, how to implement middleware etc. Its only role is to provide a simple API to update state object and to subscribe to its updates. Stores are otherwise just good ol’ Angular service classes.

</blockquote>

Basjt addresses users of `ngrx` [[home](https://ngrx.io/)]:

<blockquote>

I used ngrx in the past and I think it is a really good library for state management. But it also takes longer to learn it, because of all the features it supports. …one may not need a full blown state management library to manage state even in larger applications… I believe less complexity comes from the fact that observable store services heavily depend on Angular features (dependency injection, async pipes etc.) to do a lot of heavy lifting (e.g. cleaning-up unused state when components are destroyed, creating new instances of stores when needed etc.)…

</blockquote>

## resources

* “[On The Subject Of Subjects (in RxJS)](https://medium.com/@benlesh/on-the-subject-of-subjects-in-rxjs-2b08b7198b93)” by Ben Lesh
* “[RxJSRxJS Observables versus Subjects](https://coryrylan.com/blog/rxjs-observables-versus-subjects)” by Cory Rylan
* [StackBlitz example](https://stackblitz.com/edit/angular-rxjs-subject-and-behaviorsubject?file=app%2Fthing%2Fthing.component.ts) showing the differences among `Observable.from([])`, `Subject` and `BehaviorSubject`

@[BryanWilhite](https://twitter.com/bryanwilhite)
