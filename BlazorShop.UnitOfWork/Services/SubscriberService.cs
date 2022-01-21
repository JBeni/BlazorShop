﻿namespace BlazorShop.UnitOfWork.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ISubscriptionService _subscriptionService;

        public SubscriberService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService, ISubscriptionService subscriptionService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
            _subscriptionService = subscriptionService;
        }

        public List<SubscriberResponse> GetAll()
        {
            try
            {
                var result = _unitOfWork.SubscriberRepository.GetAll();
                var subscribers = _mapper.Map<List<SubscriberResponse>>(result);
                return subscribers;
            }
            catch (Exception ex)
            {
                return new List<SubscriberResponse>
                {
                    new SubscriberResponse
                    {
                        Error = "There was an error while getting the subscribers... " + ex.Message ?? ex.InnerException.Message
                    }
                };
            }
        }

        public SubscriberResponse Get(int id)
        {
            try
            {
                var result = _unitOfWork.SubscriberRepository.Get(id);
                var subscriber = _mapper.Map<SubscriberResponse>(result);
                return subscriber;
            }
            catch (Exception ex)
            {
                return new SubscriberResponse
                {
                    Error = "There was an error while getting the subscriber by id... " + ex.Message ?? ex.InnerException.Message
                };
            }
        }

        public RequestResponse AddSubscriber(SubscriberResponse subscriber)
        {
            try
            {
                var entity = _unitOfWork.SubscriberRepository.Get(subscriber.Id);
                if (entity != null) throw new ArgumentNullException();

                var customer = _userService.GetUserById(new GetUserByIdQuery { Id = subscriber.CustomerId });
                var subscription = _subscriptionService.Get(subscriber.SubscriptionId);

                entity = new Subscriber
                {
                    Status = subscriber.Status,
		            DateStart = subscriber.DateStart,
		            CurrentPeriodEnd = subscriber.CurrentPeriodEnd,
		            Customer = _mapper.Map<User>(customer),
		            Subscription = _mapper.Map<Subscription>(subscription),
                };

                _unitOfWork.SubscriberRepository.Add(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the subscriber", ex));
            }
        }

        public RequestResponse UpdateSubscriber(SubscriberResponse subscriber)
        {
            try
            {
                var entity = _unitOfWork.SubscriberRepository.Get(subscriber.Id);
                if (entity == null) throw new ArgumentNullException();

                var subscription = _subscriptionService.Get(subscriber.SubscriptionId);

                entity.Status = subscriber.Status;
                entity.CurrentPeriodEnd = subscriber.CurrentPeriodEnd;
                entity.Subscription = _mapper.Map<Subscription>(subscription);

                _unitOfWork.SubscriberRepository.Update(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the subscriber", ex));
            }
        }

        public RequestResponse DeleteSubscriber(int id)
        {
            try
            {
                var entity = _unitOfWork.SubscriberRepository.Get(id);
                if (entity == null) throw new ArgumentNullException();

                _unitOfWork.SubscriberRepository.Delete(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the subscriber", ex));
            }
        }
    }
}